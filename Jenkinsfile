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
                bat "dotnet restore"
                bat "dotnet build"
            }
        }
        
        stage('Test') {
            steps {
                bat "dotnet test"
            }
        }
        
        stage('Publish') {
            steps {
                bat "dotnet publish -c Release -o ./publish"
            }
        }
    }
}
