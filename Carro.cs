using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Concessionária
{
    public class Carro
    {
        private String codigo;
        private String marca;
        private String modelo;
        private String km;
        private String ano;

        public void setCodigo(String _codigo) { codigo = _codigo; }
        public void setModelo(String _modelo) { modelo = _modelo; }
        public void setMarca(String _marca) { marca = _marca; }
        public void setAno(String _ano) { ano = _ano; }
        public void setKm(String _km) { km = _km; }

        public String getCodigo() {  return codigo; }
        public String getModelo() { return modelo; }
        public String getMarca() { return marca; }
        public String getAno() { return ano; }
        public String getKm() {  return km; }

    }
}
