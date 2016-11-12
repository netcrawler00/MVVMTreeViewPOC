using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewPOC.Model
{
  /// <summary>
  /// Call him God. He holds the universe and all its constellations in his arms.
  /// </summary>
  public class RootObject
  {
    /// <summary>
    /// The collection of entities in this constellation
    /// </summary>
    public ObservableCollection<Constellation> Constellations { get; } = new ObservableCollection<Constellation>();


    /// <summary>
    /// I told you it was god
    /// </summary>
    public void CreateUniverse()
    {
      var constellation = new Constellation() { Name = "Andromeda" };
      constellation.Entities.Add(new Entity() { Name = "Alphératz" });
      constellation.Entities.Add(new Entity() { Name = "Mirach" });
      constellation.Entities.Add(new Entity() { Name = "Almach" });
      Constellations.Add(constellation);

      constellation = new Constellation() { Name = "Centaurus" };
      Constellations.Add(constellation);

      constellation = new Constellation() { Name = "Draco" };
      Constellations.Add(constellation);

      constellation = new Constellation() { Name = "Lyra" };
      Constellations.Add(constellation);

      constellation = new Constellation() { Name = "Orion" };
      Constellations.Add(constellation);

      constellation = new Constellation() { Name = "Phoenix" };
      Constellations.Add(constellation);

    }
  }
}
