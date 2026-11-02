//using Pedidos = CuartoProyecto.Models.Pedidos;
using CuartoProyecto.Services;
using Spectre.Console;

// bool running = true;

string[] options = [
  "1. Agregar un pedido",
  "2. Eliminar un pedido",
  "3. Mostrar todos los pedidos",
  "4. Salir"
];
var pedidosService = new PedidosServices();
while (true) {
  var selections = new SelectionPrompt<string>()
    .Title("Indica la opción a seleccionar: ")
    .HighlightStyle(Color.GreenYellow)
    .AddChoices(options)
    .WrapAround();

  var option = AnsiConsole.Prompt(selections);
  
  var Pedidos = pedidosService.FindAll();
  switch (option) {
    case "1. Agregar un pedido":
      Console.WriteLine("Agregando un pedido");
      AnsiConsole.Clear();
      
      var pedido = AnsiConsole.Ask<string>("Ingrese su [green][/]nombre: ");
      var apellido = AnsiConsole.Ask<string>("Ingrese su [green][/]apellido: ");
      var direccion = AnsiConsole.Ask<string>("Ingrese su [green][/]dirección: ");
      var telefono = AnsiConsole.Ask<string>("Ingrese su [green][/]teléfono: ");  
      var Pedido = AnsiConsole.Ask<string>("Ingrese su [green][/]pedido: "); 
      
      var pedidos = new CuartoProyecto.Models.Pedidos {
        Nombre = pedido,
        Apellido = apellido,
        Direccion = direccion,
        Telefono = telefono,
        Pedido = Pedido,

      };

      pedidosService.Create(pedidos);
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Pedido agregado correctamente.[/]");

      break;
    case "2. Eliminar un pedido":
      Console.WriteLine("Eliminando un pedido");
      break;
    case "3. Mostrar todos los pedidos":
      AnsiConsole.Clear();

      var table = new Table()
        .Title("Lista de mis pedidos")
        .BorderColor(Color.Yellow)
        .RoundedBorder(); // .ShowRowSeparators()

      table.AddColumn("Id");
      table.AddColumn("Nombre");
      table.AddColumn("Apellido");
      table.AddColumn("Dirección");
      table.AddColumn("Teléfono");
      table.AddColumn("Pedido");
      

      foreach (var  pedidos1 in Pedidos) {
        table.AddRow(pedidos1.Id.ToString(), pedidos1.Nombre, pedidos1.Apellido, pedidos1.Direccion, pedidos1.Telefono, pedidos1.Pedido);
      }

      AnsiConsole.Write(table);
      break;
    case "4. Salir":
      AnsiConsole.Clear();
      AnsiConsole.MarkupLine("[green]Fin de la aplicación.[/]");
      // running = false;
      // break;
      return;
  }
}