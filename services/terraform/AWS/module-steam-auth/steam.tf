# These are the variables used in this module. They are set in the modules.tf file
# in the parent directory.


variable "aws_region" {}
variable "k8s_cluster_name" {}
variable "environment" {}



# This file defines the external IP addresses needed to expose the services.

resource "google_compute_address" "steam_auth_ip" {
    name   = "${var.k8s_cluster_name}-steam-auth-address-${var.environment}"
    region = var.aws_region
}

output "steam_auth_host" {
  value = google_compute_address.steam_auth_ip.address
}



# This resource creates and rolls out a Cloud Endpoints service using gRPC on google cloud

resource "google_endpoints_service" "steam_auth_endpoint" {
  service_name         = "steam-auth-${var.environment}.endpoints.${var.gcloud_project}.cloud.goog"
  project              = var.gcloud_project
  grpc_config          = templatefile("./module-steam-auth/spec/steam_auth_spec.yml", { project: var.gcloud_project, target: google_compute_address.steam_auth_ip.address, environment: var.environment })
  protoc_output_base64 = filebase64("./module-steam-auth/api_descriptors/steam_auth_descriptor.pb")
}


output "steam_auth_dns" {
  value = google_endpoints_service.steam_auth_endpoint.dns_address
}
