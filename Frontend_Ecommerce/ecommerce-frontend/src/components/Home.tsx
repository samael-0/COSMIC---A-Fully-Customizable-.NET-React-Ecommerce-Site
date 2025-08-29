import React, { useEffect } from "react";
import CoverImg from "../assets/Images/CoverPic.jpg";
import ShopImg from "../assets/Images/shopnow.jpg";
import ShopImg2 from "../assets/Images/shopnow2.jpg";
import { FaCaretSquareLeft, FaCaretSquareRight } from "react-icons/fa";
import { useState } from "react";
import ShowCase from "./ShowCase";
import ProductCard from "./ProductCard";

function Home() {
  const Images = [ShopImg2, ShopImg];

  const [currentImage, setCurrentImage] = useState(0);
  const [fade, setFade] = useState(true);

  function next() {
    setFade(false);
    setTimeout(() => {
      setCurrentImage((prev) => {
        const nextimg = prev + 1;
        if (nextimg >= Images.length) {
          return 0;
        } else {
          return nextimg;
        }
      });
      setFade(false);
    }, 300);
  }

  // useEffect(()=>{

  //   const autoChange = setInterval(next, 1000)
  //   return () => {
  //   clearInterval(autoChange);
  // };

  // },[])

  function prev() {
    setCurrentImage((next) => {
      const previmg = next - 1;
      if (previmg < 0) {
        return Images.length - 1;
      } else {
        return previmg;
      }
    });
  }

  return (
    <>
      <div className="p-8 mt-[10rem]  ">
        <img
          src={CoverImg}
          alt="Cover"
          className="w-full h-[500px] object-cover rounded-2xl  "
        />
      </div>
      <div className="relative p-8">
        <button
          className="absolute top-1/2 left-1/2  -translate-x-1/2 -translate-y-1/2  border-2
          border-amber-50 p-3 rounded-2xl max-w-[300px] w-full text-2xl text-amber-50  hover:bg-white/50 hover:text-black 
                    hover:scale-104 
                   transition duration-700 shadow hover:shadow-lg"
        >
          shopnow
        </button>
        <button
          className="absolute top-1/2 left-12 transform -translate-y-1/2 text-5xl text-white "
          onClick={prev}
        >
          <FaCaretSquareLeft />
        </button>
        <button
          className="absolute top-1/2  right-12 transform -translate-y-1/2 text-5xl text-white"
          onClick={next}
        >
          <FaCaretSquareRight />
        </button>
        <img
          src={Images[currentImage]}
          alt="Cover"
          className="w-full h-[500px] object-cover object-[center_40%] rounded-2xl  "
        />
        {/* <ShowCase/> */}
      </div>
      <ShowCase />
      {/* <ProductCard id={1} name="shawan" imageOne="hehe" imageTwo="22"/> */}
    </>
  );
}

export default Home;
