import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
// import Auth from './Auth';
import Protected from './Components/Protected';
import Public from './Pages/Public';
import useAuth from './hooks/useAuth';

function App() {

  const [isLogin, token] = useAuth();

  return isLogin ? <Protected token={token} />: <Public/>;
  // return (
  //   <div className='lol'>
  //     <img className='img1' src="logo2.jpg" alt="lol" />
  //     <div className='auth'>
  //       <h1>Авторизация</h1>
  //         <button
  //           type="button"
  //           className="bat btn btn-dark btn-lg"
  //           onClick={() => { <Auth/>}}
  //         >
  //           Войти
  //         </button>
  //     </div>
  //   </div>
  // )
}

export default App;
