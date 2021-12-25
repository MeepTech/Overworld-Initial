﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Overworld.Data {

  public partial class Ows {
    public partial class Command {

      /// <summary>
      /// A reversed IF conditional that can run a command if the condition is "not true"/false
      /// </summary>
      public class IF_NOT : Ows.Command.Type {

        IF_NOT()
          : base(
              new("IF-NOT"),
              new[] {
                typeof(IConditional),
                typeof(Command)
              }
            ) {
        }

        public override Func<Program, Data.Character, IList<Token>, Variable> Execute {
          get;
        } = (program, executor, @params) => {
          if(((IConditional)@params.First()).ComputeFor(executor).Not.Value) {
            (@params[1] as Command)
              .ExecuteFor(executor);
          }

          return null;
        };
      }
    }
  }
}
