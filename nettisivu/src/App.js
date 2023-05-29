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
        <div className="p-4 bg-midnight/70 rounded-xl flex flex-col gap-8 items-center">
          <img src={PistolImg} width="200px" />
          <div className="w-[320px] text-white">
            Use multiple different and unique weapons
          </div>
        </div>
        <div className="p-4 bg-midnight/70 rounded-xl flex flex-col gap-8 items-center">
          <img src={ZombieImg} width="200px" />
          <div className="w-[320px] text-white">
            Eliminate as many zombies as possible without dying
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
