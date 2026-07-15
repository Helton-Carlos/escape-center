import { Card } from "@/components/Card";
import { Table } from "@/components/Table";
import { CardInfo } from "@/utils/Home";

export function Dashboard() {
  const columns = ['','Cliente', 'Serviço', 'Status'];
  const rows = [
    {
      id: '1',
      cliente: 'John Doe',
      servico: 'Revisão',
      status: 'Em andamento'
    },
    {
      id: '2',
      cliente: 'Jane Smith',
      servico: 'Escapamento',
      status: 'Concluído'
    }
  ]

  return (
    <div className="p-4 max-w-7xl mx-auto w-full">
      <h1 className="text-2xl my-4">Dashboard</h1>

      <div className="flex flex-wrap gap-4">
        {CardInfo.map((card, index) => (
          <Card
            key={index}
            title={card.title}
            description={card.description}
            imageUrl={card.imageUrl}
          />
        ))}
      </div>

      <Table 
        columns={columns} 
        data={rows}
      />
    </div>
  )
}
