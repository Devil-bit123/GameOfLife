FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar el archivo csproj al contenedor
COPY GameOfLife/GameOfLife.csproj ./GameOfLife/

# Restaurar las dependencias
RUN dotnet restore ./GameOfLife/GameOfLife.csproj

# Copiar el resto del código al contenedor
COPY . .

# Publicar la aplicación
RUN dotnet publish ./GameOfLife/GameOfLife.csproj -c Release -o /app/output

# Etapa final, copiar los archivos publicados y configurar el contenedor
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/output .

# Exponer los puertos que la aplicación usará
EXPOSE 80
EXPOSE 5001

# Comando de entrada
ENTRYPOINT ["dotnet", "GameOfLife.dll"]
