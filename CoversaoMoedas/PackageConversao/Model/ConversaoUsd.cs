using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PackageConversao.Model
{
    public class ConversaoUsd : IConversao
    {
        public string Executa(double valor, double cotacao)
        {
            return (valor / cotacao).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }
    }
}