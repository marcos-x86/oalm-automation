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
                bat "dotnet clean build"
            }
        }
    }
}
