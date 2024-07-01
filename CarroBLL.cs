using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionária
{
    internal class CarroBLL
    {
        public static void conecta()
        {
            CarroDAL.conecta();
        }
        public static void desconecta()
        {
            CarroDAL.desconecta();
        }
        public static void validaCodigo(Carro carro, char op)
        {
            Erro.setErro(false);
            if (carro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            if (op == 'r')
            {
                CarroDAL.readCarro(carro);
            }
            else
                CarroDAL.deleteCarro(carro);
        }
        public static void validaDados(Carro carro, char op)
        {
            Erro.setErro(false);
            {
                if (carro.getCodigo().Equals(""))
                {
                    Erro.setMsg("O código é de preenchimento obrigatório!");
                    return;
                }
                if (carro.getModelo().Equals(""))
                {
                    Erro.setMsg("O modelo é de preenchimento obrigatório!");
                    return;
                }
                if (carro.getMarca().Equals(""))
                {
                    Erro.setMsg("A marca é de preenchimento obrigatório!");
                    return;
                }
                if (carro.getAno().Equals(""))
                {
                    Erro.setMsg("O Ano é de preenchimento obrigatório!");
                    return;
                }
                if (carro.getKm().Equals(""))
                {
                    Erro.setMsg("A kilometragem é de preenchimento obrigatório!");
                    return;
                }
                try
                {
                    int.Parse(carro.getAno());
                }
                catch (Exception)
                {
                    Erro.setMsg("O valor do ano deve ser numérico!");
                    return;
                }

                if (int.Parse(carro.getAno()) <= 0)
                {
                    Erro.setMsg("O valor do ano deve ser positivo!");
                    return;
                }
                if (op == 'c')
                    CarroDAL.createCarro(carro);
                else
                    CarroDAL.updateCarro(carro);
            }
        }
    }
}
