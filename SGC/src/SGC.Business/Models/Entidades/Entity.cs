namespace SGC.Business.Models.Entidades
{
    public abstract class Entity
    {
        #region Protected Constructors

        protected Entity()
        {
            Id = new long();
        }

        #endregion Protected Constructors

        #region Public Properties

        public long Id { get; set; }

        #endregion Public Properties
    }
}