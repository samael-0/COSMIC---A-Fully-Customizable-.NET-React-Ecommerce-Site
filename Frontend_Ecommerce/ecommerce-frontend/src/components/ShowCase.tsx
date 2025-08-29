import React, { useState } from 'react'
import product1 from "../assets/Images/productshowcase3.jpeg"
import { BsArrowLeftCircle, BsArrowRightCircle } from "react-icons/bs";

function ShowCase() {


type Product = {
    id: number;
    name: string;
    image: string;
    price?:string | number
  
    };


  // Mock data (pretend it's from backend)
  const products: Product[] = [
    { id: 1, name: "Product 1", image: product1,  },
    { id: 2, name: "Product 2", image: product1 },
    { id: 3, name: "Product 3", image: product1 },
    { id: 4, name: "Product 4", image: "https://via.placeholder.com/150" },
    { id: 5, name: "Product 5", image: "https://via.placeholder.com/150" },
    { id: 6, name: "Product 6", image: "https://via.placeholder.com/150" },
    { id: 7, name: "Product 7", image: "https://via.placeholder.com/150" },
    { id: 8, name: "Product 8", image: "https://via.placeholder.com/150" },
    { id: 9, name: "Product 9", image: "https://via.placeholder.com/150" },
    { id: 10, name: "Product 10", image: "https://via.placeholder.com/150" },
    { id: 11, name: "Product 11", image: "https://via.placeholder.com/150" },
    { id: 12, name: "Product 12", image: "https://via.placeholder.com/150" },
  ];



  const [startIndex , setStartIndex]= useState<number>(0);
  const productsperpage=3


  const visibleProducts = products.slice(startIndex, startIndex + productsperpage)


  function handleNext(){
    if(startIndex+productsperpage<products.length){
        setStartIndex(startIndex+productsperpage);

    }else{
        setStartIndex(0);
    }
  }

  function handlePrev(){
    if(startIndex>0){
        setStartIndex(startIndex - productsperpage)
    }else{
        setStartIndex(products.length - productsperpage)
    }
  }



  





  return (
    

<div className='flex flex-col items-center'>
    <h2 className='font-sedwick text-3xl'>New Arrivals</h2>
    <div className='flex justify-between p-6 mt-4 bg-[#d1d1ad] w-full flex-wrap items-center ' >
      <button className='h-4 text-4xl active:scale-95 ' onClick={handlePrev}>{<BsArrowLeftCircle/>}</button>
        {visibleProducts.map((product)=>{
            return(
        <div className='flex flex-col border-2 bg-[#F7F7F2] rounded-xl border-red-500  p-6 gap-4 items-center'>
        <img className='h-[17rem] w-[14rem]' src={product.image} alt={product.name} />
                <h2>{product.name}</h2>
                <p className=' hidden display-none'>{product.id}</p>
                <button className="px-6 py-2 rounded-xl bg-gradient-to-r from-cyan-700 to-cyan-900 
         text-amber-50 font-semibold shadow-md border-2 border-cyan-800 
         hover:from-cyan-600 hover:to-cyan-800 hover:shadow-lg 
         hover:scale-105 active:scale-95 transition-all duration-300 ease-in-out">buyNow</button>
                </div>)
        }
        
        )}
        <button onClick={handleNext}>{<BsArrowRightCircle/>}</button>


        
    </div>
        
        

    </div>

  
  )
}



export default ShowCase;