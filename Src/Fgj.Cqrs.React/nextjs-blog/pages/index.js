import Layout from '../components/layout';

export default function Home() {
  return (
    <Layout title="Iniciativa fullstack">
      <main>

        {/* Breadcrumb */}
        <section id="breadcrumb" className="breadcrumb">
          <div className="container">
            <div className="row">
              <nav>
                <ul>
                  <li><a href="/">Home</a></li>
                  <li>|</li>
                  <li><a href="/">Blog</a></li>
                  <li>|</li>
                  <li>Criando aplicação com React e .Net Core</li>
                </ul>
              </nav>
            </div>
          </div>
        </section>

      </main>
    </Layout>
  )
}
