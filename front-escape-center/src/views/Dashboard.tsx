import { Card } from "@/components/Card";
import { CardInfo } from "@/utils/Home";

export function Dashboard() {
  return (
    <div className="p-4 max-w-6xl mx-auto w-full">
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
    </div>
  )
}
