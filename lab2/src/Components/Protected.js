import React, { useState, useEffect, useRef } from "react";
import Header from "./Header";

const Protected = ({ token }) => {
  const isRun = useRef(false);

 // const [data, setData] = useState(null);

  useEffect(() => {
    if (isRun.current) return;

    isRun.current = true;

    window.ttoken = {
        tok: token
    };
    // const config = {
    //   headers: {
    //     authorization: `Bearer ${token}`,
    //   },
    // };

    // axios
    //   .get("http://localhost:80/api/pupil")
    //   .then((res) => setData(res.data))
    //   .catch((err) => console.error(err));
  }, []);

  return <Header/>;
};

export default Protected;