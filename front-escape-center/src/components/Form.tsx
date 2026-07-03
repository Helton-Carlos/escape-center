export function Form() {
  return (
    <form className="bg-gray-800 w-90 px-4 py-4 flex flex-col gap-5 mx-auto">
      <h1 className="text-2xl text-center font-bold mt-2">
        Escape Center
      </h1>

      <div>
        <label htmlFor="email" className="text-white">
          E-mail
        </label>

        <input 
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
          type="password" 
          placeholder="*******" 
          className="input mt-2"
        />
      </div>

      <button className="btn btn-primary">Login</button>
      <button className="btn btn-link text-white">Cadastrar</button>
    </form>  
  )
}