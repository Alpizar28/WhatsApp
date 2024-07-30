# Aplicación de Mensajería Instantánea Similar a WhatsApp

### Descripción General
Este proyecto es una implementación de una aplicación sencilla de mensajería instantánea, similar a WhatsApp, desarrollada en C# utilizando .NET 8. La aplicación utiliza sockets para el envío y recepción de mensajes. 
Cada instancia de la aplicación actúa como un cliente de chat único que puede comunicarse con otras instancias.

### Características
- **Aplicación Windows Forms**: Una interfaz gráfica de usuario (GUI) construida con Windows Forms.
- **Comunicación mediante Sockets**: Utiliza sockets para el intercambio de mensajes entre clientes.
- **Manejo de Eventos**: Implementa el manejo de eventos para los mensajes entrantes.

### Requisitos
- **SDK de .NET 8**
- **Visual Studio o cualquier IDE para C#**
- **Git para el control de versiones**

### Cómo Ejecutar la Aplicación
1. **Descargar el Repositorio en su computadora**

2. **Entrar a la terminal de su preferencia**:

3. **Navegar al Directorio del Proyecto**:
   ```sh
   cd <directorio-del-proyecto>
   ```
   Por ejemplo:
      ```sh
   cd "C:\Users\Pablo\OneDrive - Estudiantes ITCR\TEC\Semestre 2\00 Datos\C#\WhatsApp\WhatsApp\WhatsApp"
   ```
4. **Verificar si el documento WhatsApp.csproj esta en esa ubicacion**
      ```sh
   dir
   ```
5. **Ejecutar la Aplicación**:
   ```sh
   dotnet run --project WhatsApp.csproj --port <puerto-de-escucha>
   ```
6. **Abra otra terminal y repita desde el paso 3 al paso 5**

### Uso
1. **Conectar un Cliente**:
   - Ingrese un número de puerto en el campo `Puerto escucha` en uno de las terminales.
   - Ingrese el número de `Puerto escucha` del otro terminal en el campo de `Puerto destino`.
   - Haga clic en el botón `Conectar` para comenzar a escuchar mensajes entrantes en el puerto especificado.
  
   - Repita el proceso con el otro terminal inviertiendo el `Puerto escucha` y `Puerto destino`

2. **Enviar un Mensaje**:
   - Ingrese el mensaje en el campo vacío.
   - Haga clic en el botón `Enviar` para enviar el mensaje.
