import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { ToastContainer, toast } from 'react-toastify';

export function Form() {
  const navigate = useNavigate();

  const [email, setEmail] = useState('');
  const [name, setName] = useState('');
  const [password, setPassword] = useState('');
  const [register, setRegister] = useState(false);

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    if(register) {
      if(!name || !email || !password) {
        toast.error("Preencha todos os campos");
        return;
      }

      const response = await fetch('http://localhost:3000/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, email, password })
      });

      if(response.ok) {
        toast.success("Cadastro realizado com sucesso!");
        setRegister(false);
      } else {
        toast.error("Erro ao cadastrar usuário");
      }
    } else {
      if(email && password) {
        navigate('/'); 

        toast("Bem vindo ao Escape Center!");
      } 

      toast("Erro ao logar, verifique os campos!")
    }

    
  }
  return (
    <form className="bg-gray-800 w-90 px-4 py-4 flex flex-col gap-5" onSubmit={handleSubmit}>
      <h1 className="text-2xl text-center font-bold mt-2">
        Escape Center
      </h1>

      <h3>
        {register ? "Cadastre-se" : "Login"}
      </h3>


      {
       register && (
        <div>
          <label htmlFor="name" className="text-white">
            Nome
          </label>

          <input 
            value={name}
            onChange={(e) => setName(e.target.value)}
            type="text" 
            placeholder="Nome" 
            className="input mt-2"
          />
        </div>
       )
      }

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
          {register ? "Cadastrar" : "Login"}
        </button>

        <button className="btn btn-link text-white" type="button" onClick={() => setRegister(!register)}>
          {register ? "Já tem uma conta? Faça login" : "Não tem uma conta? Cadastre-se"}
        </button>
      </div>

      <ToastContainer />
    </form>  
  )
}