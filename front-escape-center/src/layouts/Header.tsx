import { Link } from 'react-router-dom'

export function Header() {
  return (
    <header className="w-full h-20 bg-gray-800 flex items-center justify-center">
      <div className="w-full max-w-7xl flex items-center justify-between px-4">
        <h1 className="text-2xl">Escape Center</h1>

        <nav className="flex items-center gap-4">
          <ul>
            <li>
              <Link to="/login" className="text-white hover:text-gray-400">
                Sair
              </Link>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  )
}