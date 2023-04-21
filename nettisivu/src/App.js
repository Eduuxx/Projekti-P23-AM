import gnomeWanted from "images/gnomewanted.png";

function App() {
  return (
    <div className="h-screen w-screen flex flex-col px-8 bg-midnight">
      <div className="w-full text-yellow-500 font-bold text-6xl text-center mt-16">
        Gnome Revenge
      </div>
      <div className="flex w-full justify-center mt-16">
        <div className="text-white w-[900px] text-center">
          You have been summoned to the depths of the Scandinavian forest, where
          mischievous and demonic gnomes roam free.
          <br />
          Your mission, is to rid the forest of these pesky creatures and emerge
          victorious.
          <br />
          Armed with only your trusty weapons, you will need to outsmart and
          outmaneuver these devious creatures if you hope to survive.
        </div>
      </div>
      <div className="w-full flex justify-center">
        <img
          src={gnomeWanted}
          width="300px"
          className="rounded-sm shadow-xl mt-16"
        />
      </div>
    </div>
  );
}

export default App;
