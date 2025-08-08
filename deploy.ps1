# Script para construir y ejecutar la aplicación en Docker

# Construir y levantar los contenedores
docker-compose up --build -d

# Esperar que SQL Server esté listo
Write-Host "Esperando que SQL Server esté listo..."
Start-Sleep -Seconds 30

# Ejecutar el script de inicialización de la base de datos
docker exec -it api-db-1 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "YourStrongPassword123!" -i /init-db.sql

Write-Host "API disponible en: http://localhost:5000"
Write-Host "Para probar el login, enviar POST a: http://localhost:5000/api/login"
Write-Host "Ejemplo de payload JSON:"
Write-Host '{"identificacion": "123456789", "password": "password123"}'
