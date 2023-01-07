using DelegatesEventsExemplo2;

var lista = new Lista();


lista.Notificar += Notificar;
lista.Add("A");
lista.Add("B");
lista.Add("C");
lista.Add("D");

Action<Lista> action = new(i => Console.WriteLine(i));
Func<Lista, bool> func = new(i => i.Id == 1);
Predicate<Lista> pred = new(i => i.Id == 999);

//lista.PrintAllItems(action);
//Console.WriteLine(lista.GetItemById(func));
Console.WriteLine(lista.ExistItem(pred));

static void Notificar()
{
    Console.WriteLine("Fui notificado");
}
