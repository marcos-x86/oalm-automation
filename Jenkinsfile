pipeline {
    agent any

    stages {
        stage("Checkout") {
            steps {
                git branch: "my_specific_branch",
                    credentialsId: "github_token",
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
