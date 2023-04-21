import React, { useState, useEffect, useRef } from "react";
import Header from "./Header";

const parseJwt = (token) => {
  try {
    return JSON.parse(atob(token.split('.')[1]));
  } catch (e) {
    return null;
  }
};

const Protected = ({ token }) => {
  const isRun = useRef(false);

  // console.log(parseJwt(token).resource_access.BackendClient.roles[0]);
  window.ttoken = {
    tok: token,
    role: parseJwt(token).resource_access.BackendClient.roles[0]
  };

  useEffect(() => {
    if (isRun.current) return;

    isRun.current = true;
  }, []);

  return <Header />;
};

export default Protected;