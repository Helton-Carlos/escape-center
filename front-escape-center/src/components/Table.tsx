interface TableProps {
  columns: string[];
  data: { 
    id: string, 
    cliente: string, 
    servico: string, 
    status: string 
  }[];
}

export function Table({ columns, data }: TableProps) {
  return (
    <div className="overflow-x-auto rounded-box border border-base-content/5 bg-base-100 mt-8">
      <table className="table">
        <thead>
          <tr>
            {columns.map((column, index) => (
              <th key={index}>{column}</th>
            ))}
          </tr>
        </thead>
        <tbody>
        {
          data.map((row, index) => (
            <tr key={index}>
              <td>{row.id}</td>
              <td>{row.cliente}</td>
              <td>{row.servico}</td>
              <td>{row.status}</td>
            </tr>
          ))
        }
        </tbody>
      </table>
    </div>
)}