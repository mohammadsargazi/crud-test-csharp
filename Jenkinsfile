pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                script {
                    // Use the installed .NET Core SDK to restore and build the project
                    sh "dotnet restore"
                    sh "dotnet build MyDotNetApp.sln"
                }
            }
        }
        
     
    }
}
