# This file defines a Google Kubernetes Engine cluster.

# This creates the top level VPC which by itself contains no subnets or IP range
resource "google_compute_network" "container_network" {
  name                    = "container-network-${var.environment}"     ### container-network-test
  auto_create_subnetworks = false
}


resource "google_compute_subnetwork" "container_subnetwork" {
  name          = "container-subnetwork-${var.environment}"             ### container-subnetwork-test
  ip_cidr_range = "10.2.0.0/16"                                         ### EC2 instances get IPs from this range
  region        = var.gcloud_region
  network       = google_compute_network.container_network.self_link
}

resource "google_container_cluster" "primary" {
  name       = "${var.k8s_cluster_name}-${var.environment}"             ### io-online-services-test
  location   = var.gcloud_zone                                          ### us-east1
  network    = google_compute_network.container_network.name            ### container-network-test
  subnetwork = google_compute_subnetwork.container_subnetwork.name      ### container-subnetwork-test

  remove_default_node_pool = true
  initial_node_count       = 1

  ip_allocation_policy {
    # The IP address range for the cluster pod IPs
    cluster_ipv4_cidr_block  = "10.0.0.0/16"                            ### Pods get IPs from this range
    # The IP address range of the services IPs in this cluster  
    services_ipv4_cidr_block = "10.1.0.0/16"                            ### clusterIPs for services from this range
  }

  master_auth {
    username = "admin"
    password = random_string.password.result
  }
}

resource "google_container_node_pool" "primary_preemptible_nodes" {
    name       = "${var.k8s_cluster_name}-node-pool-${var.environment}"
    location   = var.gcloud_zone
    cluster    = google_container_cluster.primary.name
    node_count = 4

    node_config {
      preemptible  = true
      machine_type = "n1-standard-1"

      oauth_scopes = [
        "https://www.googleapis.com/auth/compute",
        "https://www.googleapis.com/auth/devstorage.read_only",
        "https://www.googleapis.com/auth/logging.write",
        "https://www.googleapis.com/auth/monitoring",
        "https://www.googleapis.com/auth/service.management.readonly",
        "https://www.googleapis.com/auth/servicecontrol",
      ]
    }
}

resource "random_string" "password" {
  length           = 16
  special          = false
  override_special = "/@\" "
}
