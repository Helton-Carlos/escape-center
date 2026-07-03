interface CardProps { 
  title: string;
  description: string;
  imageUrl?: string;
}

export function Card({ title, description, imageUrl }: CardProps) {     
  return (
    <>
      <div className="card bg-base-100 image-full w-96 shadow-sm">
      <figure>
        <img
          src={imageUrl || "https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"}
          alt="Shoes" />
      </figure>
      <div className="card-body">
        <h2 className="card-title">{title}</h2>
        <p>{description}</p>

        <div className="card-actions justify-end">
          <button className="btn btn-primary">{title}</button>
        </div>
      </div>
    </div>
    </>
  )
 }