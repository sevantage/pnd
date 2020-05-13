using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp.Builder
{
    public abstract class Builder
    {
        public abstract void AddPart();
    }

    public class Director
    {
        public Builder Builder { get; set; }

        public void Construct()
        { }
    }

    public class ConcreteBuilderA : Builder
    {
        public ProductA ProductA { get; }
        public override void AddPart()
        {

        }
    }

    public class ProductA
    {
    }

    public class ConcreteBuilderB : Builder
    {
        public ProductB ProductB { get; }
        public override void AddPart()
        {

        }
    }

    public class ProductB
    {
    }
}