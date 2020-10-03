# === .tfvar Variables === #

# === AWS === #
variable "aws_region" {}
variable "vpc_cidr_block" {}

# === K8s === #
variable "k8s_cluster_name" {}
variable "environment" {}
variable "workstation-external-cidr" {}


# === Providers === #                                      #

terraform {
  required_version = ">= 0.12"
}

provider "random" {
  version = "~> 2.1"
}

provider "local" {
  version = "~> 1.2"
}

provider "null" {
  version = "~> 2.1"
}

provider "template" {
  version = "~> 2.1"
}

provider "aws" {
  region = var.aws_region
}

provider "kubernetes" {
  load_config_file       = "false"
  host                   = data.aws_eks_cluster.cluster.endpoint
  token                  = data.aws_eks_cluster_auth.cluster.token
  cluster_ca_certificate = base64decode(data.aws_eks_cluster.cluster.certificate_authority.0.data)
}

# === Online Service Modules === #

module "steam_auth" {
  source           = "./module-steam-auth"
  aws_region    = var.aws_region
  k8s_cluster_name = var.k8s_cluster_name
  environment      = var.environment
}

output "steam_auth_host" {
  value = module.steam_auth.steam_auth_host
}

output "steam_auth_dns" {
  value = module.steam_auth.steam_auth_dns
}