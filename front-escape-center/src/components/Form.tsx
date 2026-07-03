import { useState } from "react";
import { useNavigate } from "react-router-dom";

export function Form() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if(email && password) {
      navigate('/'); 
    } 
  }
  return (
    <form className="bg-gray-800 w-90 px-4 py-4 flex flex-col gap-5 mx-auto" onSubmit={handleSubmit}>
      <h1 className="text-2xl text-center font-bold mt-2">
        Escape Center
      </h1>

      <div>
        <label htmlFor="email" className="text-white">
          E-mail
        </label>

        <input 
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          type="e-mail" 
          placeholder="e-mail" 
          className="input mt-2"
        />
      </div>

      <div>
        <label htmlFor="password" className="text-white">
          Senha
        </label>

        <input 
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          type="password" 
          placeholder="*******" 
          className="input mt-2"
        />
      </div>

      <div className="flex flex-col gap-2">
        <button className="btn btn-primary" type="submit">
          Login
        </button>

        <button className="btn btn-link text-white" type="button">
          Cadastrar
        </button>
      </div>
    </form>  
  )
}