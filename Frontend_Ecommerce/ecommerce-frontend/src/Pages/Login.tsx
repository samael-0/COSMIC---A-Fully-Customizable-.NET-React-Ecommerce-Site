import {
  Theme,
  Flex,
  Card,
  Text,
  TextField,
  Button,
  Heading,
  Link,
} from "@radix-ui/themes";
import * as Toast from "@radix-ui/react-toast";

import "@radix-ui/themes/styles.css";
import { useContext, useState, type FormEvent } from "react";
import { data } from "react-router-dom";
import UserContext from "../Context/UserContext";





interface NavbarProps {
  darkMode: boolean;
}


export const Login = () => {





  


  const [open, setOpen] = useState(false);
  const [toastMessage, setToastMessage] = useState("");
  






  
  const handlesubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const element = e.currentTarget;
    const formdata = new FormData(element);
    formdata.get("username");
    formdata.get("pass");

    fetch("api/LoginRegister/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username: formdata.get("username"),
        password: formdata.get("pass"),
      }),

      credentials: "include",
    })
      .then((res) => res.text())
      .then((data) =>{
      setToastMessage(data)
      setOpen(true)
    } );
      
  };

  return (
    // <form onSubmit={handlesubmit} className="mt-48">
    //   <label htmlFor="">username</label>
    //   <input className="border-2" name="username" type="text" />

    //   <label htmlFor="">password</label>
    //   <input className="border-2" name="pass" type="text" />
    //   <br />
    //   <button className="border-b hover:cursor-crosshair" type="submit">
    //     login
    //   </button>
    // </form>
    <Theme	accentColor="mint"
	grayColor="olive"
	panelBackground="solid"
	scaling="100%"
	radius="medium">
      <div className={`min-h-screen flex items-center justify-center font-poppins  `}>

      <Flex align="center" justify="center" className="mt-[6rem]" >
      <Card variant="surface">
        <form onSubmit={handlesubmit}>
         <Flex  direction="column" gap="3" align="center" justify="center"  className="p-4 w-[20rem] h-[20rem]" >
          <Heading>Login Page</Heading>
       <Flex align="center" gap="3" className="w-full">
      <TextField.Root placeholder="UserName" name="username" className="w-full">
   
      </TextField.Root>
      </Flex>
       <Flex align="center" gap="3" className="w-full"></Flex>
            <TextField.Root placeholder="Password" name="pass" className="w-full">

      </TextField.Root>

   <Flex align="center" gap="3" className="w-full">
  <Button
    variant="classic"
    type="submit"
    color="bronze"

    className="flex-1"

    style={{ width: "100%" }} // ensure the inline style enforces full width
  >
    Log In
  </Button>
</Flex>
        </Flex>
        </form>
      </Card>


      </Flex>


      
     
     <Toast.Provider swipeDirection="left">
  <Toast.Root
    open={open}
    onOpenChange={setOpen}
    className="bg-white border border-gray-300 shadow-lg rounded-lg p-4 flex items-center gap-2 w-80 max-w-full"
  >
    <Toast.Title className="font-poppins text-gray-900 text-sm break-words">
      {toastMessage}
    </Toast.Title>
    <Toast.Close
      className="ml-auto text-gray-500 hover:text-gray-900 cursor-pointer"
      aria-label="Close"
    >
      ✕
    </Toast.Close>
  </Toast.Root>

  {/* Move the toast viewport to bottom-right */}
  <Toast.Viewport
    className="fixed bottom-5 right-5 w-80 max-w-full z-[9999] flex flex-col gap-2"
  />
</Toast.Provider>

 </div>
    </Theme>
  ); 
};
