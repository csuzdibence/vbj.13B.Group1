namespace VBJ._13B.Group1.WebApp.Models
{
    /// <summary>
    /// Ez az osztály reprezentál egy elkészítendő teendőt
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// Ez a property állítja az azonosítót
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Ez a property állítja a teendő címét
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Azt jelöli, hogy a teendő elkészült-e
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
