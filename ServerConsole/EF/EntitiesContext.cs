using System;
using System.Data.Objects;

namespace ServerConsole.EF
{
    class EntitiesContext:ObjectContext,IUnitOfWork
    {
        private ObjectSet<EF.File> _files;
        private ObjectSet<EF.Peer> _peers;
        private ObjectSet<EF.User> _users;
        public EntitiesContext()
            : base("name=AfekaTorrentEntities", "AfekaTorrentEntities")
        {
            _files = CreateObjectSet<EF.File>();
            _peers = CreateObjectSet<EF.Peer>();
            _users = CreateObjectSet<EF.User>();
        }

        public ObjectSet<EF.File> Files
        {
            get { return _files; }
        }

        public ObjectSet<EF.Peer> Peers
        {
            get { return _peers; }
        }
        public ObjectSet<EF.User> Users
        {
            get { return _users; }
        }

        public void Save()
        {
            try
            {
                SaveChanges();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.InnerException.Message);
            }
        }
    }
}
