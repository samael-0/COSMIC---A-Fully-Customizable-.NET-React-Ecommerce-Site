import React, { useState, useEffect } from "react";
import { FaCartArrowDown, FaUser } from "react-icons/fa";
import { HiMenu } from "react-icons/hi";
import Sidebar from "./Sidebar";
import logo from "../assets/Images/logo2.png";
import { Link } from "react-router-dom";



function Navbar() {
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);

  function sideToggle() {
    setIsSidebarOpen(!isSidebarOpen);
  }

  useEffect(() => {
    if (isSidebarOpen) {
      document.body.style.overflow = "hidden";
    } else {
      document.body.style.overflow = "auto";
    }

    return () => {
      document.body.style.overflow = "auto";
    };
  }, [isSidebarOpen]);

  return (
    // <nav className='flex justify-between p-6 bg-[#F7F7F2]'>
    //     <button>MyStore</button>

    //     <ul className='flex gap-10'>
    //         <li>Homepage</li>
    //         <li>Products</li>
    //         <li>About</li>
    //         <li>Profile</li>
    //     </ul>

    //     <button>
    //          🛒 Cart
    //     </button>

    // </nav>

    <>
      <nav
        className="fixed top-10 flex justify-between px-6 pt-6 pb-2 z-50 w-full transition-colors duration-300
        bg-nav   dark:bg-primary-navdark dark:text-darktext"
      >
        <HiMenu className="text-3xl cursor-pointer" onClick={sideToggle} />

        <div className="flex flex-1 justify-center">
          {/* <img src={logo} alt="" className="h-16 " /> */}
   <Link to="/" className="font-sedwick text-[2.5rem]">
    CosmicFits
  </Link>
        </div>
        {/* <div className='font-poppins text-2xl pt-1'>BullyBoy</div>     */}

        <div className="flex gap-7">
          <FaCartArrowDown className="text-3xl  cursor-pointer" />
          <Link to="/login">
  <FaUser className="text-2xl cursor-pointer" />
</Link>
        </div>
      </nav>

      {isSidebarOpen && (
        <div className="fixed top-10 left-0  w-64 bg-[#F7F7F2] z-40">
          <Sidebar />
        </div>
      )}
    </>
  );
}

export default Navbar;
