import React, { useState, useEffect, useRef } from "react";
import Header from "./Header";

const Protected = ({ token }) => {
  const isRun = useRef(false);

  window.ttoken = {
    tok: token
  };

  useEffect(() => {
    if (isRun.current) return;

    isRun.current = true;
  }, []);

  return <Header />;
};

export default Protected;