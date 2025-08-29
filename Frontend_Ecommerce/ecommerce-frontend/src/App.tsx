import { useContext, useEffect, useState } from "react";

import "./App.css";
import Navbar from "./components/Navbar";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./components/Home";
import { Login } from "./Pages/Login";
import ProductCard from "./components/ProductCard";

import Products from "./Pages/Products";
import { ThemeContextt, ThemeProvider } from "./Context/themeContext";
import { ThemeContext } from "@radix-ui/themes";
import Cart from "./Pages/ProductView";
import ProductView from "./Pages/ProductView";



function App() {


  const [themeMode, setThemeMode] = useState("light")

  const lightTheme =()=>{
    setThemeMode("light")

  }

  const darkTheme = ()=>{
    setThemeMode("dark")
  }





// useEffect(() => {
//     document.documentElement.classList.remove("light", "dark")
//     document.documentElement.classList.add(themeMode)
//   }, [themeMode])


  useEffect(() => {
    document.documentElement.classList.remove("light", "dark");
    if (themeMode === "dark") {
        document.documentElement.classList.add("dark");
    }
    // If themeMode is "light", we add no class
}, [themeMode]);







  


  return (


      <ThemeProvider value={{themeMode,lightTheme,darkTheme}}>
      <BrowserRouter>

       <div className="dark:bg-primary-dark dark:text-darktext" >
        {/* Header and Navbar always visible */}
        <Header  />
        <Navbar  />
   

        {/* Main page content changes based on route */}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
             <Route path="/products" element={<Products />} />
                  <Route path="/productview" element={<ProductView />} />
          {/* Add more pages here */}
        </Routes>
        </div>

      </BrowserRouter>
              </ThemeProvider>

    


  );
}

export default App;
