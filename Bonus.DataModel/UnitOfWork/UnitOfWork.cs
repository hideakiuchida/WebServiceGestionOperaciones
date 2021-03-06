﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.Validation;
using Bonus.DataModel.GenericRepository;

namespace Bonus.DataModel.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly GestionOperacionDbEntities _context = null;
        private GenericRepository<usuario> _userRepository;  
        private GenericRepository<token> _tokenRepository;
        private GenericRepository<foto> _fotoRepository;
        private GenericRepository<inspeccion> _inspeccionRepository;
        private GenericRepository<orden> _ordenRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new GestionOperacionDbEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<inspeccion> InspeccionRepository
        {
            get
            {
                if (this._inspeccionRepository == null)
                    this._inspeccionRepository = new GenericRepository<inspeccion>(_context);
                return _inspeccionRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<foto> FotoRepository
        {
            get
            {
                if (this._fotoRepository == null)
                    this._fotoRepository = new GenericRepository<foto>(_context);
                return _fotoRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<usuario> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<usuario>(_context);
                return _userRepository;
            }
        }
        
        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<token>(_context);
                return _tokenRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<orden> OrdenRepository
        {
            get
            {
                if (this._ordenRepository == null)
                    this._ordenRepository = new GenericRepository<orden>(_context);
                return _ordenRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    //_context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}