namespace DelegatesEventsExemplo2
{
    public delegate void Notificacao();
    public class Lista
    {
        private List<Lista> _items = new();
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime DataCriacao => DateTime.Now;
        public IReadOnlyCollection<Lista> BuscarLista => _items;
        public event Notificacao Notificar;

        public void Add(string item)
        {
            var itemLista = new Lista();
            itemLista.Id += _items.Count;
            itemLista.Item = item;
            _items.Add(itemLista);
            EventHandler();
        }

        private void EventHandler()
          => Notificar();

        public override string ToString()
         => string.Join("-", Id, Item, DataCriacao);

        #region Func
        public Lista GetItemById(Func<Lista, bool> func)
            => _items.FirstOrDefault(func);
        #endregion

        #region Action
        public void PrintAllItems(Action<Lista> action)
            => _items.ForEach(action);
        #endregion

        #region Predicate
        public bool ExistItem(Predicate<Lista> pred)
         => _items.Exists(pred);
        #endregion
    }
}