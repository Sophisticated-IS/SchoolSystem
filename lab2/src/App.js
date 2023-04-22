import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Protected from './Components/Protected';
import useAuth from './hooks/useAuth';

function App() {
  const [isLogin, token] = useAuth();
  return isLogin ? <Protected token={token} />: null;
}

export default App;
