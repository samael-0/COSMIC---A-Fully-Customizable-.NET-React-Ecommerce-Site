import React from "react";
import { useState, useEffect } from "react";
import { data, Link } from "react-router-dom";

function Sidebar() {
  const [Categories, setCategories] = useState<string[]>([]);
  const [selectedCategory, setSelectedCategory] = useState([]);

  useEffect(() => {
    fetch("https://fakestoreapi.com/products/categories")
      .then((res) => res.json())
      .then((data: string[]) => setCategories(data))
      .catch((err) => console.error(err));
  }, []);

  return (
    <div className="flex flex-col  w-67 h-screen pt-14 px-7 bg-nav dark:bg-primary-navdark dark:text-darktext">
      <div className="flex flex-col gap-10 pt-10">
         <Link to="/" className="hover:underline">
          Home
        </Link>

         <Link to="/login" className="hover:underline">
          Login
        </Link>

        <select className="appearance-none" name="Categories">
          <option value="">Categories</option>
          {Categories.map((cat, index) => (
            <option key={index} value={cat}>
              {cat}
            </option>
          ))}
        </select>

        <div>Products</div>
        <div>Contact</div>
      </div>
    </div>
  );
}

export default Sidebar;
