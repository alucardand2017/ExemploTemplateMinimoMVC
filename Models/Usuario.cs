namespace AULA08MVCTEMPLATEMINIMO.Models;

public class Usuario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }

    private static List<Usuario> listagem = new List<Usuario>();

    public static IQueryable<Usuario> Listagem
    {
        get{
            return listagem.AsQueryable();
        }
    }

    public static void Salvar(Usuario usuario)
    {
        var buscaUsuario = listagem.Find(u => u.Id == usuario.Id);
        if(buscaUsuario != null)
        {
            buscaUsuario.Nome = usuario.Nome;
            buscaUsuario.Email = usuario.Email;
        }
        else
        {
            if(listagem.Count > 0)
            {
            int maiorId = listagem.Max(a=> a.Id);
            usuario.Id = maiorId + 1;               
            }
            else
                usuario.Id =  1;
            listagem.Add(usuario);
        }
    }

    public static void Excluir(int id)
    {
        var usuario = listagem.First(a=>a.Id == id);
        if(usuario != null)
            listagem.Remove(usuario);
    }
    static Usuario()
    {
          listagem.Add(
            new Usuario {Id = 1, Nome = "Fulano", Email="Fulano@gmail.com"});
        listagem.Add(
            new Usuario {Id = 2, Nome = "Ciclano", Email="Ciclano@gmail.com"});
        listagem.Add(
            new Usuario {Id = 3, Nome = "Beltrano", Email="Beltrano@gmail.com"});
        listagem.Add(
            new Usuario {Id = 4, Nome = "Zircano", Email="Zircano@gmail.com"});
        listagem.Add(
            new Usuario {Id = 5, Nome = "Gotano", Email="Gotano@gmail.com"});
    }

}