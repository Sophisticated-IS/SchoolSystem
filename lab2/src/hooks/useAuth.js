import React, { useState, useEffect, useRef } from "react";
import client from "../keypar";

const useAuth = () => {
  const isRun = useRef(false);
  const [token, setToken] = useState(null);
  const [isLogin, setLogin] = useState(false);

  useEffect(() => {
    if (isRun.current) return;

    isRun.current = true;
    client
      .init({
        onLoad: "login-required",
      })
      .then((res) => {
        setLogin(res);
        console.log(res);
        setToken(client.token);
      });
  }, []);

  return [isLogin,token];
};

export default useAuth;
