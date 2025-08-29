import React, { useContext } from "react";
import { useState, useEffect } from "react";
import { ThemeContextt } from "../Context/themeContext";

interface HeaderProps {
  toggleDarkMode: () => void;
  darkMode: boolean;
}

function Header() {

    const {themeMode,lightTheme,darkTheme} = useContext(ThemeContextt)


  const headerinfo = [
    "Winter Sale Coming ❄️",
    "50% Off on All Items 🛍️",
    "Free Shipping Over $50 🚚",
    "New Arrivals Just Dropped ✨",
  ];

  const [currentIndex, setCurrentIndex] = useState(0);

  useEffect(() => {
    // 4️⃣ Function to change the news index
    function changeheader() {
      setCurrentIndex((prevIndex) => {
        const nextIndex = prevIndex + 1;
        if (nextIndex >= headerinfo.length) {
          return 0;
        } else {
          return nextIndex;
        }
      });
    }

    // 5️⃣ Set interval to call changeNews every 3 seconds
    const intervalId = setInterval(changeheader, 1000);

    return () => {
      clearInterval(intervalId);
    };
  }, []);

  const [isOn, setIsOn] = useState(false);


const toggleTheme = ()=>{
  if( isOn == false){
    darkTheme()
  }else{
    lightTheme()
  }
}

  const toggleSwitch = () => {
    setIsOn(!isOn);
  };

  return (
    <div className="fixed top-0  w-full z-50 px-6 py-2  flex justify-center border-b border-black text-white bg-gray-500 ">
      <div className="flex flex-1 justify-center">
        {headerinfo[currentIndex]}
      </div>
      <div
        className={`switch ${isOn ? "on" : ""} h-6 w-11 `}
        onClick={() => {
          toggleSwitch();
          toggleTheme()
         
        }}
      >
        <div className="slider h-4 w-4"></div>
      </div>
    </div>
  );
}

export default Header;


