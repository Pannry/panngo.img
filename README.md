# panngo.img
Armazenador de imagens

## Criando o banco de dados
### Instalando ferramenta, apenas se não tiver instalado:
dotnet tool install --global dotnet-ef

### Atualizando banco
cd API/
dotnet ef database update

### Rodando a aplicação
cd API/
dotnet watch
