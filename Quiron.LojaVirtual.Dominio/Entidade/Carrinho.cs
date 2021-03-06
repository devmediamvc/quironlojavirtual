﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();
        
       
        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }
        }


        public void RemoverItem(Produto produto)
        {
            _itemCarrinho.RemoveAll(p => p.Produto.ProdutoId == produto.ProdutoId);
        }

        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        public IQueryable<ItemCarrinho> ItensCarrinho
        {
            get { return (IQueryable<ItemCarrinho>)_itemCarrinho; }
        }


    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

    }
}
