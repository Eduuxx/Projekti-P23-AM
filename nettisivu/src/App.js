import MetsaImg from "images/metsa.png";
import PistolImg from "images/pistol.png";
import ZombieImg from "images/zombie.png";

function App() {
  return (
    <div
      className="h-screen w-screen flex flex-col px-8 bg-midnight"
      // Custom style as a work-around to create transparent image background
      style={{
        background: `linear-gradient(rgba(0, 0, 0, 0.60), rgba(0, 0, 0, 0.60)), url(${MetsaImg})`,
        backgroundRepeat: "no-repeat",
        backgroundSize: "cover",
      }}
    >
      <div className="w-full text-lime-400 font-bold text-6xl text-center mt-16">
        NIGHTFALL
      </div>
      <div className="w-full flex justify-center mt-44 gap-44">
        <div className="p-4 bg-midnight/30 rounded-xl flex flex-col gap-8 items-center rounded-b-none border-b-2 border-lime-400">
          <img src={PistolImg} width="200px" />
          <div className="w-[320px] text-white">
            State of the art gunplay mechanics for handling zombies
          </div>
        </div>
        <div className="p-4 bg-midnight/30 rounded-xl flex flex-col gap-8 items-center rounded-b-none border-b-2 border-lime-400">
          <img src={ZombieImg} width="200px" />
          <div className="w-[320px] text-white">
            Zombies who had a taste of blood and they want MORE
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
