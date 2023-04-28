import MetsaImg from "images/metsa.png";

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
        ZOMBIE VIOLATION
      </div>
    </div>
  );
}

export default App;
