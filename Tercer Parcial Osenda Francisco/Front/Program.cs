using System;
using System.Collections.Generic;
using Tercer_Parcial_Osenda_Francisco.Models;
using Tercer_Parcial_Osenda_Francisco.Repositories;
using Tercer_Parcial_Osenda_Francisco.Data;
using Tercer_Parcial_Osenda_Francisco.Repositorys;
namespace Front
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<Producto> Productos = ProductoRepository.verProductos();
            List<Cliente> Clientes = ClienteRepository.verClientes();
            List<Venta> Ventas = VentaRepository.verVentas();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1 - Registrar nuevo Producto");              
                Console.WriteLine("2 - Registrar nuevo Cliente");
                Console.WriteLine("3 - Registrar Venta");
                Console.WriteLine("4 - Mostrar reporte de venta por cliente");
                Console.WriteLine("5 - Mostrar productos disponibles");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion.Trim())
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del producto:");
                        string nombreProducto = Console.ReadLine();

                        Console.WriteLine("Ingrese el precio del producto:");
                        string p = Console.ReadLine();
                        if (!decimal.TryParse(p, out decimal precioProducto))
                        {
                            Console.WriteLine("Precio inválido. Presione una tecla para volver atras.");
                            Console.ReadKey();
                            return;
                        }                   

                        Console.WriteLine("Ingrese el stock del producto:");
                        int stockProducto = int.Parse(Console.ReadLine());

                        Producto nuevoProducto = new Producto
                        {
                            Nombre = nombreProducto,
                            Precio = precioProducto,
                            Stock = stockProducto,    
                            
                        };

                        ProductoRepository.GuardarProducto(nuevoProducto);
                        Productos = ProductoRepository.verProductos();
                        Console.WriteLine("Producto guardado exitosamente.");

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Ingrese el nombre del cliente:");
                        string nombreCliente = Console.ReadLine();

                        Console.WriteLine("Ingrese el apellido del cliente:");
                        string apellidoCliente = Console.ReadLine();

                        Console.WriteLine("Ingrese el DNI del cliente:");
                        if (int.TryParse(Console.ReadLine(), out int dniCliente))
                        {
                            Cliente cliente = new Cliente (nombreCliente, apellidoCliente, dniCliente);
                            ClienteRepository.GuardarCliente(cliente);
                            Clientes = ClienteRepository.verClientes();
                        }
                        ;

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();

                        List<Producto> productosVenta = new List<Producto>();
                        Console.WriteLine("Ingrese el DNI del cliente:");
                        if (int.TryParse(Console.ReadLine(), out int DniCliente) && Clientes.Exists(c => c.Dni == DniCliente))
                        {
                            Cliente cliente = Clientes.First(c => c.Dni == DniCliente);
                            while (true)
                            {
                                Console.WriteLine("Ingrese el ID del producto:");
                                if (int.TryParse(Console.ReadLine(), out int idProducto))
                                {
                                    if (!Productos.Exists(p => p.ID == idProducto))
                                    {
                                        Console.WriteLine("El producto con el ID especificado no existe.");
                                        break;
                                    }
                                    else
                                    {
                                        Producto productoSeleccionado = Productos.First(p => p.ID == idProducto);
                                        if (productoSeleccionado.Stock <= 0)
                                        {
                                            Console.WriteLine("El producto seleccionado no tiene stock disponible.");
                                            break;
                                        }                                        
                                        else
                                        {
                                            Console.WriteLine("Ingrese la cantidad:");

                                            if (int.TryParse(Console.ReadLine(), out int cantidad))
                                            {              
                                                if (cantidad > productoSeleccionado.Stock)
                                                {
                                                    Console.WriteLine("No hay suficiente stock disponible para la cantidad solicitada.");
                                                    break;
                                                }
                                                else
                                                {
                                                    productoSeleccionado.Stock -= cantidad;
                                                    productosVenta.Add(productoSeleccionado);
                                                    Console.WriteLine("Desea agregar otro producto a la venta? Responder con Si o No");
                                                    if (Console.ReadLine().ToLower() == "si")
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }                                            
                                            }
                                    }
                                   
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("ID de producto inválido.");
                                }
                            }
                            Venta nuevaVenta = new Venta
                            {
                                ClienteID = cliente.ID,                                
                                Monto = productosVenta.Sum(p => p.Precio),   
                                Productos = productosVenta
                            };
                            VentaRepository.GuardarVenta(nuevaVenta);
                            Ventas = VentaRepository.verVentas();
                            Productos = ProductoRepository.verProductos();

                            Console.WriteLine("Venta registrada exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("DNI de cliente inválido.");
                        }

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();                 
                        Console.WriteLine("Ingrese el DNI del cliente para ver su reporte de ventas:");
                        if (int.TryParse(Console.ReadLine(), out int clienteDNI))
                        {
                            var ventasCliente = VentaRepository.verVentasPorCliente(clienteDNI);
                            if (ventasCliente.Any())
                            {
                                Console.WriteLine("Reporte de ventas:");
                                foreach (var venta in ventasCliente)
                                {
                                    Console.WriteLine($"ID: {venta.ID}, Monto: {venta.Monto}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontraron ventas para el cliente especificado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("DNI de cliente inválido.");
                        }

                        Console.WriteLine("Para volver al menu principal presione una tecla");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Productos disponibles:");
                        foreach (var P in Productos)
                        {
                            Console.WriteLine($"ID: {P.ID}, Nombre: {P.Nombre}, Precio: {P.Precio}, Stock: {P.Stock}");
                        }


                        Console.WriteLine("Para volver al menu principal presione una tecla");
                            Console.ReadKey();
                            break;                     
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
