namespace AdventOfCode2021;

public class Day10
{
    private static readonly Dictionary<char, int> CorruptScores = new Dictionary<char, int>
    {
        {')', 3},
        {']', 57},
        {'}', 1197},
        {'>', 25137}
    };

    private static readonly Dictionary<char, int> MissingScores = new Dictionary<char, int>
    {
        {'(', 1},
        {'[', 2},
        {'{', 3},
        {'<', 4}
    };

    public static void Part1(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day10 Part1");

        var inputs = input.Split(Environment.NewLine).ToArray();
        Console.WriteLine(inputs.Select(ReduceBrackets).Where(l => l.Length > 0)
            .Select(l => l.ToCharArray().Cast<char?>().FirstOrDefault(c => c is ']' or '>' or ')' or '}')).Where(c => c != null).Select(c => CorruptScores[c.Value]).Sum());
    }

    public static void Part2(string input)
    {
        Console.WriteLine();
        Console.WriteLine("Day10 Part2");
        
        var inputs = input.Split(Environment.NewLine).ToArray();
        var uncompletedInputs = inputs.Select(ReduceBrackets).Where(l => l.Length > 0)
            .Where(l => !l.ToCharArray().Any(c => c is ']' or '>' or ')' or '}'));
        var uncompletedScores = new List<long>();
        foreach (var uncompletedInput in uncompletedInputs)
        {
            long score = 0;
            foreach (var character in uncompletedInput.Reverse())
            {
                score *= 5;
                score += MissingScores[character];
            }

            Console.WriteLine(score);
            uncompletedScores.Add(score);
        }
        Console.WriteLine(uncompletedScores.OrderBy(i => i).ToArray()[(int)Math.Ceiling(uncompletedScores.Count / 2.0) - 1]);
    }

    private static string ReduceBrackets(string input)
    {
        var output = input.Replace("()", "").Replace("[]", "").Replace("<>", "").Replace("{}", "");
        return output.Length != input.Length ? ReduceBrackets(output) : output;
    }

    public static string TestInput = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

    public static string Input = @"{<[[<<<[[{[[<<()()>>[([]<>){{}{}}]]]<(<{{}<>}{{}{}}><{<>[]}[{}{}]>)({(())}<[(){}][(){}]>)>}]<<<(<<{}
{[({({([({(((<[]()>[()<>]){[<>[]](<>[])})<<<[]()}>(<()()>)>)}[{((<{}[]>{<>()}){[<>{}]<<><>>})(({[]()}<<>()>)<
(((([{{{<{<[[<()<>><<>{}>]]{<(<>())>}>{<[([]<>)<{}{}>][[<><>][<>[]]]>[{(<>{})[<>()]}<<()[]>[[]<
<<[<([[{{{[({<<>()>}<<<>[]>([]())>){{{{}[]}<(){}>)}]{{[(()())[(){}]]<<[]{}>({}[])>}({<<><>>}<([]<>){()[]}>)}
<[(({[({<<[[[{<>{}}(<><>))<(<>[])[{}[]]>]<[([][])[(){}]]>]([<[()()](<>[])>]<(<{}()>[{}<>])({<>[
(<[[{[[[(<((<<{}{}><[]<>>><[{}<>][<>[]]>)<(<{}<>><{}{}>)[{()[]}<<>()>]>)>[(<{({}{})}[{()[]}{[]<>}]>){<(([]
(([[({{{(<([({[]{}}){{[][]]}])>)[<([[[{}]{(){}}][([]())]]([{[][]}{<>()}](({}()){<>{}})))[{({
{(<<([([(<<[{((){})([]<>)}]<{{{}{}}{{}[]}}<{(){}}{()[]})>><([<[]{}>([]<>)](<()<>>)){<([]<>
{[<<[<{{((({<[[]{}]{{}}>{<{}<>>[<>[]]}})<{[(<><>><{}<>>][{[]{}}]}[[[[][]]<<>{}>]{[[]()][[]<>]}]>)[(
({<(<([{<{<[(((){}){(){}})]>}[{{{{()()}<[]()>}{{<>()}<{}{}>}}[[{{}{}}[<><>]]{({}[]>[[]{}]}]}({{{()()
{[[{([{<<{<(<<{}()>[()]>)<{{()()}}[<[][]>(<>{})]>>{[<{<>()){()<>}>{{()()}[<>()]}][[[{}[]]]<{{}[]}<()(
{{<<<<<[[([{<[{}[]]{()<>}>{<<>()>{{}<>}}}<<{{}()}{()()}>{[()<>]({}[])]>]{[(<{}{}>)<({}[])>]<{({}<>)}{({}())
({(<<{[<<{<(<[<>()][[][]]><[{}<>]({}[])>)[[[<>[]][[]()]]<{[]{}}[{}{}]>]>{[(<[]()>{<>{}})][<{{}}<{
(<<<[[({<[[(<<[]{}>>[(()<>)[<>{}]])<{(<>[])}(<<>()>[[]{}])>]<[({[]()}{{}{}})<{{}()}<{}<>>>]>][[({<<>()>{[]()}
{{{[<[([<(<{[([][])[{}[]]]{[()()]{{}()}}}><[<([][])(<>())><{()[]}({}<>)>]<<<(){}><<><>>>((()()){
[(((([{({<(<(<[]<>>{()[]})><{(<><>){{}[]}}{(()<>)([][])}>)>})}][({{[[{<(<><>){{}()}>((<>()){<>[]
([{<{<({(<[(<({}<>)><{[]}[{}[]]>)(<[[][]]{[]{}}>{{[]}((){})})]{(((()){{}()})(([][])({}{})))[(<()[]><(
[([{{<{(<[{{((()())<[]{}>){{{}<>}<<><>>}}[<([]())>[(()[])<{}{}>]]}{[({(){}}{(){}])<<[]()>{{}()}>
(<[<{{[<<({<<{<><>}><<()[]>[<><>]>>}{[(((){}){()<>}}<<[]()>{(){}}>]{{{{}[]}[{}<>]}[{{}{}}<(){}>]}}){{({
<([([[<[({<<{{[][]}<{}[]>}<<()[]>[()<>]>>>})((<(<[[]]((){})>{([]()){<><>}})>)(<<<<[]<>>[[]()])>>([[
[<<{<(<<{{[({<<>()><{}[]>})<{[<>()](<><>)}[{{}()}{[]()}]>]}}({<[{<()<>>}[<<>>]]((<[][]>{[][
{{(<({[((<([({()<>})[{{}[]}(()<>))]{[{[]<>}][{()<>}]})([({<><>}{{}()})])>)({<(((()<>)(<><>)))>((
[(<{({[<{<[<([{}()](<>{}))>]([([[]<>]<()<>>){<()>}]{{[[]()]{{}{}}}[{[]}{{}<>}]})>}<([<[<<>[]>]{<(){}>{
[[[[<(<({<[[<{()}{{}[]}><[<><>]<()[]>>](<([]{})[{}]>)]>}<[{[[{(){}}]{(<><>)}][<<[][]>{(){}
{(({({[{{((<[([]())((){})]>){[{(<>[])}<([]{})[[]<>]>]({<()<>>[[]<>]}[<()>{<>[]}])})({<([[][]]((){}))([<>{}])
<(<(<<{[<<{<<[()[]][[]()]><([][])<{}()>>}}>[<<<<{}<>>>{[{}][{}{}]}>[<[()()]{{}[]}>[{[][]}([])]]>[[<<[][]>(
<<{{({<<(([{{([][])(()<>)}}(<<[]{}>>)])([{[(()[])]}<{{<><>}<[]<>>}[<{}<>><[]<>)]>]{{<[{}[]]
({[[[[(([[[{<({})([]())>{{<>{}}}}][[<<[]>[<>()]>]{[[[]<>][<>{}]]{[<>[]]}})][[<(<(){}>{()[]})><[[()[
(((((([{{{(<<(<>{}){<>}><(()[])<()[]>>>{[<{}<>>(<>())}<{{}()}>})((([(){}]{<>})[{[]{}}{{}[]
(([([(((<[(({[<>()]{[][]}})[{{[]()>[[]{}]}(<<>{}><{}<>>)]){[({[]}(<>[]))([()()][<>{}])]({({}
[(<({{([[<(((<<>()>[[]<>])({{}()}<()<>>))[[{[]()}<()<>>][{()()}<{}[]>]])>({(<({}{})<()[]}>[{()
{{{[([<{{{([<<<>{}>{()<>}>{<{}()><<><>>}]([{()}]))<{[<()()>{()[]}]{({}[])[<>()]}}>}}}({<(({({
[([([<[<(<[{{{<>()}{()[]}}({()[]}[{}<>])}{[{<>}]([[][]]<(){}>)}]>[[{<[<>()][{}()]>(((){}>[<>[]])}{{{<>(
{{[{{[[<{(<([[[][]]([]<>)])>)<{<<{<>()}[<>()]><((){})<<><>>>>([<<><>>(()<>)]([(){}}{[]<>}))}>}(({{{{[]}{
[[[[({[<({{[[(<><>)]{<<>[]>([]{})}]<[{[]}{()()}]([<>()]([]<>>)>}})>{{<([{<{}{}>{()}}])({<[<>()](<><>)>
{[({<[({[{[({[{}()][[]<>]}((()<>)<{}<>>))<[{{}}({}{})]>]{[<<<>[]>[[][]]>(({}[])(()[]))>{(([]{})({}[]))([
[<<([{{(<<[<[[{}[]]](<[]{}>[<>{}])>[[<{}[]>(<>[])]{([][])[()[]]}]][[{{()[]}[<>{}]}(<<>{}>[[]
<[(([{([([<{[[(){}]<<>{}>]}[[[()()]{{}<>}]]>[[{({}{})[()()]}([()()][<>[]])]{<[[]<>][[][]]>}]]{{<{[<>
[<[[[[([[{[[<[{}{}]([]<>)>[({}[])<[]<>>]][<{()()}[<>[]]>([[]]<<><>>)]]}([<{{{}[]}}{(()<>>({}[
<[<{[(<{({[<[[[][]]([][])]<([]){{}<>}>>[({<>{}}<[]>)]]([[([]{})[[]()]][[[]{}]({}{})]](<[{}<>
({[<([(<[[<([[(){}]<<>{}>])({[[]{}]<()[]>}<<[]<>>{[][]}>)>{<[<[]()><{}[]>]([<>()]({}[]))><(
({<<<{<({[[{[{<>{}}[<><>]]}{(({})[()()])<<()<>>([]{})>}]]]{<{{([[]<>](<>[]))[[{}()]({}())]}}>((<([{}<>])>{{<[
[{([{[[{{<{<[{[]()}<[]{}>]>({<{}[]>{<>[]}})}[(({{}<>}<{}<>]){[[]{}]({}[])})]>}}]({([[([<()()>{[]
<[{([([{[{<(([<>[]]{<>()})<{{}<>}>){([<><>])<(()[])<<>{}>>}><{{[{}<>]{<>}}[(())[()<>]]}<{[{}{}]{{}{}}}<{{}<>
[{<<([{{(((<{<<>()>[{}()]}>{<<<>[]><[]()>>}){[(([][])([]()))<{{}[]}[[]()]>][[{{}<>}({}{})]{({}{})(<
{({[((<([[[{{([])[()()]}({{}{}}))<(<[]<>>[()[]])>]<<([[]<>])<[<>()][[]<>]>>({[<><>]{{}[]}}({()[]
{[(<(<{[({[(<<[]>{<>{}}>[{<><>}([]())])(<[[][]]<()<>>>[(()[])])]<{[{()[]}[<>{}]]}[{<(){}>(<>{})}<<<>()>>]
(<{<[<({{{{([({}{})[[]{}]]({{}<>}<()[]}))}(<<{<>()}{()<>}>{[<>{}][()[]]}>{<<[][]>{<>()}><(<>{})<{}[]>>})}
{(<<{[({<<[(<{{}{}}<[]<>>>((<>())([]<>)))]>><<({<{[]<>}([]<>)>{[()()]}}<<{{}<>}<()()>>(<()()
<([([<(<[({[[({}()){()<>}](({}{})(<><>))][{({}<>)<{}{}>}{([]){(){}}}]})]>)<[[{<{{(()){<>[]}}({{}()}
<<<([{[({{{((<{}()>{()()})[[<>()]])[[[{}()]<{}()>]{{[]<>}{{}())}]}<<{<<>><<><>>}[{{}[]}(<><>)
<([<[<{[[[{[{[<><>][{}<>]}(<[]{}>)]}([{{<>()}<{}[]>}{([]<>)[(){}]}]<{((){})<[]()>}[<[]()><()[]>]>
[([[[[[({{[(<[{}<>]<{}()>><[<><>]{<>()}>)]}<{(<(()<>)<{}{}>>{{()<>}(()()}})}>})(<[<([<<>[]>((){})]([[]<>]<()
{(<[[{(((([[([{}()]<{}()))[({}{}){[]}]](<<<>[]>>([<>{}]))][(<({}{})<()[]>><<[]{}><{}[]>>)])(<([([][])[
({(([{{<{{{<[<<>[]>{()<>}][([][]){()<>}]>([<()>(<><>)]<{<><>}<[]>>)}<{[[<>[]][<>{}]]<{<>()}{[][]
{[([[[(([<{<{[[]<>]<<>()>}<<()()>([]{})>>[<<()[]>(<>())>[(()<>)]]}>]{{({{{{}[]}({})}<{{}<>}[[]()]>}((
[<([[<[{{{[[[<<>{}>]{<()[]>{[]<>}}]{([[]{}]({}()))}]}}}(<{<[[({}{})<()()>]]({({}<>)[[]]}{[<><>]{<>{}}})>(<[
<<(<<{{(({<[<<[]{}>{()()}}[[()[]]]]{[(<>{}){<>}]{[{}](<>)}}><{<(()())<[]<>>>[<(){}>(<>[])]
{<(<[<[(((<{((()[])([]<>))([[]<>]({}[]))}><<([<>())<[]<>>)(<{}[]>({}<>))>[[([]())]({()()}{{}<>})
[[((<[[[{{<{<{{}()}[{}()]>{{[]{}}[<><>]}}>}<{[<[(){}]<<><>>]([{}<>]<<><>>)]}(<<[{}<>]<<>{}>
<[{{[[{<[{(({[(){}]({}{})})[([{}<>][()()])[<[][]><{}<>>]])}](<({(([]<>){()[]})[([]())((){})]}{{{<>{}}<[]()>}<
<{((<([[{<<[(<{}()><{}[]>)]>[([{<>()}<()()>]<{()[]><()[]>>){<[{}[]]>[{[][]}(<><>)]}]>{{[{{{}<>}{<>}}[[(){}]<(
{<[({(<{{[([{{[]{}}((){})}[[{}[]]<{}()>]]((<[]<>>)<([]()){{}[]}>))(<<{()[]}{[]})>[[(()())]{[()<>][<>(
<<{[[[[{<({<[[{}()]]{{[]<>}{[]}}><{{{}()}({}{})}>}{([({}[])({}())](({}[])))[<{[]<>}[<>()]><<[]<>>(<>[])>]}
[(([<<[{[{<({{()[]}<<><>>})[[([]())[[]{}])(<<>{}>)]>(<{{[][]}[{}()]}([{}{}][(){}])>((<<>[]>(()
[({<<[[<{[<<({[]()}<()<>>)>]]{{<[[[]][{}<>]]>}{([[<>{}][{}{}]]<((){})(()[])>)}}}([{((<{}[]>)[<{}[]><{}()>])}
{[[((<[{<<([{<<><>>([]{})}<(<><>)<<>()>>][{[[]{}]{()()}}<({}{})([][])>])><<{({<>{}}[<>()])((
[[[<{{(<((([{<[]{}>({}<>)}[<<>()>]]<<(()[]){{}[]}>{(()<>){{}<>}}>){{{(()())[<><>]}[[[]<>]{<>[]}]}}))[
(<({[({[[({{<{<>{}}<()[]>>[{(){}}<<>[]>]}[[<[][]><()<>>]({<>{}}{[]()})]}{(([[]<>][{}[]])(<[]<>>([
{([<{[<({{{({[[][]][()()])[<<>()><[][]>])}<{{{[]()}[{}()]}{{<>()}{<>}}}((({}())<{}{}>){(<>{})[<>{}]})>}})(((
([[[[[[{(((((<<>()>[[]<>])<{()()}[()<>]>){<[()[]]<<>[]>>(<<>{}}{{}[]})}))<<[([()()][[]()])[{()[]}([]())]][<([
({{((((<{<[{[(<>{})][<()()>[[]()]]}]{({(<>())[[]()]}{<[][]><[][]>})}>}>{<<{{(({}())[<>])((()[])<[]<>>)}}[
<(<[[[<<{([<<[[]<>]{<>[]}><{()()}([]<>)>>]{<{(<>())((){})}{[{}{}]<<>{}>}>})({([[{}{}]])[(<<>()>[
{[(<{<[[{<{{(<()[]><<>{}>){[()<>]<{}<>>}}[[[<>{}][[]<>]]]}<[[({})<<>[]>]]{{<()<>><<>[]>}<{()[]}((){}
({[{(<<{[<{({[()()]{{}}}<({}{}){()()}>)}<{(({}{})[<>[]]){([]())[[][]]}}{(<[]<>)[()])[[<>()]]}>>
(({<<[<[<<<({<{}[]>({}{})}{<{}[]><{}[]>})>>(<<(<()()>{[]{}})({()<>}[()()])>[{[{}()][[]]}({<>()}}]>(
<<(<(<[{([{<[[<>{}]<{}<>>]>{<(()[])(()())><{<>[]}{()()}>}}([{({}<>){<>{}}}{{<>[]}[{}{}]}]([<[]()>((){})
{[{([({[[<<<{{[]{}}<[]{}>}[<()[]><[]<>>]>([{{}[]][[][]]]{{(){}}({}[])})>(<{[<>{}](()<>)}>{[<[]()>
([[[<(<{[({<({()()}{<>()})((<>[])<[]<>>)>}<{<<{}()><<>>>}({{{}[]}}[(()[])[()<>]])>)<[<((()())[<>{}])(
{<(((<[((((({<[]>[[]{}]}))[(<[[][]][{}{}]>){{[<>()][[]<>]}([()()](<><>))}])){(<[{[<>()][{}()]
({([{<(((<{[<[{}[]]<<>>>({{}[]}[[]()])]([<(){}>])}{<[{<>[]}{[]<>}][<<><>){<>{}}]>[<((){})([]{})>[[{}{}][()
<[{[<[{[({{<(({}<>}[[]()])>({{[][]}}<[(){}](()[])>)}})([[{{<<>()>([]{})}[<<>{}>[<><>]]}]])]
{(<{([{[[({[(<[]{}>)({{}[]}{()()}))<{(()[])}[[()()]{{}[]}]>}<{<(()<>)>{{[]{}}({}())}}({{{}[]}{<
[<<{<{<<(<([<(<>()){[]()}>[({}<>)({}<>)]][(([]{}){()[]})[{{}()}(()())]])>{([{{()[]}<<>[]>}<{<>[
{{[[(([([({([([]<>)(()())][{<>()}{(){}}])})])]([{{[<{{{}<>}(<>())>{[()()]<<>[]>}>[{(()){{}[
[({({({(({{(<[()()][{}<>]>[[{}()]{(){}}])<[<<>[]>][<{}>(<>{})]>}(((({}())({}{}))){{(()[])<[][
<(<(<[([<[{[<(()<>)<()[]>><(<>())([][])>]{<[{}<>]{{}()}>{[[]{}](<>{})}}}<[<([]{})><{{}<>}([]())>]>]>
<<<(<<[({{{<{({}<>)<()[]>}<[()<>]{(){}}>><{[[]()]<[]{}>}[({}{})<(){}>]>}(<[<<>[]>{()[]}]>)}[<{[<{}>[{}{
{(<((<[{{[[[[<{}{}]<{}()>]][{({}{})<<>{}>}[<()[]>(()())]]]{([<[]()><[]{}>](<{}()>))({<<><>>(<>())}{
{({{[[<[{<{{(<<>>)(<[]()>[()])}([({}<>)])}[[{[()<>][()[]]}]({<[]<>>{<>()}})]><<(<<{}()>{<>[]
{{{[{[<<{[[{[{{}<>}<[][]>]{(()[])<<>()>}}[<{()()}[(){}]><<()[]>>]]{<((<>{})({}()))[<(){}>([][])]>{({{}[]}<
<{{[<{({{{[<{{<>()}{{}()}}>]<{<[()[]](<><>)><[<>[]]{(){}}>}<([(){}]<{}{}>){(())}>>}[([{[[]<>][{}<>]}[{()}(
[<<[{{(({({<{{{}{}}{<>[]}}({[][]}{<>[]})>[{[{}<>][<>[]]}[({}[])[[]<>]]]})}))<(<[[<(({}()))[<<>()>{(
{<<([<{({[{{[({}[])<<>{}>]([()<>]<(){}>)}<([{}[]]({}{}))>}[<<<<>{}>[[][]]>{<<>[]><()>}>[<<<>><[][]>
[({(<({[<[{{[<<>[]>[()[]]]<<<>[]>>}}<{([{}[]](<>{}))[{<>}{{}<>}]}(<<[][]>>[{[]<>}])>]>[(<(({<>[]}{<><>}))(<
{<[[{{<<{(<(<([]<>)[[][]]>[([]{})[<>{}]])<[{<>()}{[]<>}]>>>[{(({()()}[<>[]]){({}())<[]<>>})}[(<{<>
{[[{{{<[<[{<(({}{})[{}()])[(<><>)({}())]>}{[<{[]{}}[()[]]>]<{[()()]<[]()>}<[[][]]>>}]>{{({{{()[]}{{}(
<{[<([{{[[<(<{<><>}[{}{}]><((){})>){[[()()][()[]]]{[[]<>]}}>]<<(<({}[])<{}[]>>{(<><>)<[]()>}){(<";
}