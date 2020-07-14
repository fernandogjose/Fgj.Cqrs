import Layout from '../components/layout';

export default function Home() {
  return (
    <Layout title="Iniciativa fullstack | Criando um site com React e Next">
      <section id="article" className="article">
        <div className="container">
          <div className="row">

            {/* Article */}
            <article className="col-md-12 blog-main">
              <div className="blog-post">
                <header>
                  <h2 className="blog-post-title">Criando um site com React e Next.js</h2>
                  <p className="blog-post-meta">Escrito por <a href="https://github.com/fernandogjose" target="_blank">Fernando José</a>, em 11 de julho de 2020.</p>
                </header>

                <section id="description" className="description"><br />
                  <h3>Objetivo</h3>
                  <p>O objetivo deste artigo é criar um site em <strong>ReactJS</strong> + <strong>Next.js</strong>.</p><br />

                  <h3>Porque Next.js?</h3>
                  <p>Faz com que o nosso site seja renderizado no servidor, <strong>SSR (Server Side Rendering)</strong>, e assim ser encontrado pelos <strong>motores de busca (SEO).</strong></p><br />

                  <h3>Criando o projeto com Next.js?</h3>
                  <p>Para criar um <strong>Next.js</strong> app, abra o seu terminal, dentro da pasta de sua escolha, execute o comando:</p>
                  <pre><code>npm init next-app nextjs-blog --example "https://github.com/vercel/next-learn-starter/tree/master/learn-starter"</code></pre>
                  <ul>
                    <li><b>npm init next-app</b> = Criando um next app</li>
                    <li><b>nextjs-blog</b> = É o nome do nosso app</li>
                    <li><b>--example "https://github.com/vercel/next-learn-starter/tree/master/learn-starter"</b> = Repósitorio com o template padrão que vamos usar para criar nosso app</li>
                  </ul>
                  <p>Agora temos a pasta "nextjs-blog", o nosso projeto padrão e as dependências instaladas. Vamos abrir a pasta</p>
                  <pre><code>cd nextjs-blog</code></pre>
                  <p>Então, vamos rodar o seguinte comando</p>
                  <pre><code>npm run dev</code></pre>
                  <p>Nosso site vai subir em modo de desenvolvimento na porta 3000.</p>
                  <p>Para acessar vamos abrir a url "http://localhost:3000" no browser. Pronto temos a nossa aplicação em next.js rodando!!!</p>
                  <figure><img className="img-fluid" src="/criando-site-com-react-next/home-nextjs.PNG" alt="Criando um site com Next.js"></img></figure><br />

                  <h3>Próximos passos</h3>
                  <p>Nos próximos passos vamos melhorar e estruturar o código com a criação de componentes, arquivo de configuração e estilos.</p>
                  <p>Criei dois videos sobre a criação do site com next.js explicando e melhorando o código gerado.</p>

                </section>
              </div>
            </article>
          </div>
        </div>
      </section>

      {/* Videos */}
      <section id="videos">
        <div className="container">
          <div className="row mb-2">
            <article className="col-md-6">
              <div className="card flex-md-row mb-4 h-md-250">
                <div className="card-body d-flex flex-column align-items-start">
                  <header>
                    <strong className="d-inline-block mb-2 text-primary">Parte 1</strong>
                    <h2 className="mb-0 text-dark">Criando um site com React e Next.js</h2>
                    <div className="mb-1 text-muted">11 de julho - Criado por Fernando José</div>
                  </header>
                  <p className="card-text mb-auto"> Introdução sobre o site que vamos desenvolver utilizando o react, nextJs (SSR), bootstrap com boas práticas na escritá do código</p>
                  <footer>
                    <a href="https://youtu.be/2q7_cuxKaiI" target="_blank">Assistir no youtube</a>
                  </footer>
                </div>
                <figure>
                  <img className="card-img-right flex-auto d-none d-lg-block" data-src="holder.js/200x250?theme=thumb" alt="ReactJS + Next.js" src="/criando-site-com-react-next/react-next.png" data-holder-rendered="true"></img>
                </figure>
              </div>
            </article>
            <article className="col-md-6">
              <div className="card flex-md-row mb-4 h-md-250">
                <div className="card-body d-flex flex-column align-items-start">
                  <header>
                    <strong className="d-inline-block mb-2 text-primary">Parte 2</strong>
                    <h2 className="mb-0 text-dark">Criando um site com React e Next.js</h2>
                    <div className="mb-1 text-muted">11 de julho - Criado por Fernando José</div>
                  </header>
                  <p className="card-text mb-auto">Nesta videoaula 100% prática a gente inicia o desenvolvimento do nosso site em react, nextJs (SSR), bootstrap com boas práticas e renderizando no servidor (SSR - Server Side Rendering) de forma fácil e transparente</p>
                  <footer>
                    <a href="https://youtu.be/LYLNDi3KbVA" target="_blank">Assistir no youtube</a>
                  </footer>
                </div>
                <figure>
                  <img className="card-img-right flex-auto d-none d-lg-block" data-src="holder.js/200x250?theme=thumb" alt="ReactJS + Next.js" src="/criando-site-com-react-next/react-next-1.png" data-holder-rendered="true"></img>
                </figure>
              </div>
            </article>
          </div>
        </div>
      </section>
    </Layout>
  )
}
