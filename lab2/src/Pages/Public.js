import React from "react";
import App from "../App";

const Public = () => {
   return (
    <div className='lol'>
      <img className='img1' src="logo2.jpg" alt="lol" />
      <div className='auth'>
        <h1>Авторизация</h1>
          <button
            type="button"
            className="bat btn btn-dark btn-lg"
            onClick={() => { <App/>}}
          >
            Войти
          </button>
      </div>
    </div>
  )
};

export default Public;