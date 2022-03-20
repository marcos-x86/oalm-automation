pipeline {
    agent any

    stages {
        stage("Checkout") {
            steps {
                git branch: "main",
                    credentialsId: "github_credentials",
                    url: "https://github.com/marcos-x86/oalm-automation.git"

            }
        }
        stage('Build') {
            steps {
                bat "dotnet restore"
                bat "dotnet clean"
                bat "dotnet build"
            }
        }
        stage('Run Tests') {
            steps {
                bat "run-tests.cmd ${EnvironmentName} ${Tags}"
            }
        }
    }
    post {
        always {
            allure([
                includeProperties: false,
                properties: [],
                reportBuildPolicy: "ALWAYS",
                results: [[path: "oalm-web/bin/Debug/net6.0/allure-results"]]
            ])
        }
    }
}
