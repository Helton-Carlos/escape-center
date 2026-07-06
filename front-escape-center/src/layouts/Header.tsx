import { Link } from 'react-router-dom'

export function Header() {
  const list = [
    {
      title: 'Dashboard',
      to: '/'
    },
    {
      title: 'Cadastrar Cliente',
      to: '/cadastrar-cliente'
    },
    {
      title: 'Cadastrar Serviço',
      to: '/cadastrar-servico'
    },
    {
      title: 'Cadastrar Produto',
      to: '/cadastrar-produto'
    },
  ];

  return (
    <header className="navbar bg-base-100 shadow-sm">
      <div className="flex justify-between max-w-7xl mx-auto w-full">
        <div className="dropdown">
          <label htmlFor="my-drawer-1" className="btn drawer-button">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M4 6h16M4 12h16M4 18h7" /> </svg>
          </label>

          <input id="my-drawer-1" type="checkbox" className="drawer-toggle" />
        
          <div className="drawer-side">
            <label 
              htmlFor="my-drawer-1"
              aria-label="close sidebar" 
              className="drawer-overlay"
            />
        
            <ul className="menu bg-base-200 min-h-full w-80 px-4 pt-8">
             <li>
               <Link to="/" className="btn btn-ghost text-xl my-8">Escape Center</Link>
             </li>

              { list.map((item, index) => (
                <li className='mb-2' key={index}>
                  <Link to={item.to}>{item.title}</Link>
                </li>
              ))}

              <li className='flex justify-end mt-8'>
                <Link to="/login" className="btn btn-primary my-8">Login</Link>
              </li>
            </ul>
          </div>
        </div>

        <Link to="/" className="btn btn-ghost text-xl">Escape Center</Link>
        
        <div>
          <button className="btn btn-ghost btn-circle">
            <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" /> </svg>
          </button>
          <button className="btn btn-ghost btn-circle">
            <div className="indicator">
              <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9" /> </svg>
              <span className="badge badge-xs badge-primary indicator-item"></span>
            </div>
          </button>
        </div>
      </div>
    </header>
  )
}